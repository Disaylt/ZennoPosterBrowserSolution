using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Resources;
using System.Text;
using ZennoLab.CommandCenter;
using ZennoLab.Emulation;
using ZennoLab.InterfacesLibrary.ProjectModel;
using ZennoLab.InterfacesLibrary.ProjectModel.Enums;
using ZennoPosterBrowser.Configs;
using ZennoPosterBrowser.Forms.AccountCreator;
using ZennoPosterBrowser.Forms.AccountSelection;
using ZennoPosterBrowser.Forms.Bookmarks;
using ZennoPosterBrowser.Forms.MainMenu;
using ZennoPosterBrowser.Logger;
using ZennoPosterBrowser.Services.Accounts;
using ZennoPosterBrowser.Services.BrowserActions;
using ZennoPosterBrowser.Services.VPN;
using ZennoPosterBrowser.Services.ZennoPosterBrowser;

namespace ZennoPosterBrowser
{
    /// <summary>
    /// Класс для запуска выполнения скрипта
    /// </summary>
    public class Program : IZennoExternalCode
    {
        private Instance _instance;
        private IZennoPosterProjectModel _project;
        private static readonly object _locker = new object();

        /// <summary>
        /// Метод для запуска выполнения скрипта
        /// </summary>
        /// <param name="instance">Объект инстанса выделеный для данного скрипта</param>
        /// <param name="project">Объект проекта выделеный для данного скрипта</param>
        /// <returns>Код выполнения скрипта</returns>		
        public int Execute(Instance instance, IZennoPosterProjectModel project)
        {
            lock (_locker)
            {
                _instance = instance;
                _project = project;
                BaseConfig config =  BaseConfig.InitialConfig(project);
                bool isGoodEnd = true;
                Guid guid = Guid.NewGuid();

                try
                {
                    BrowserActionsManager browserActionsStorage = new BrowserActionsManager();
                    IVPN vpn = new SmartProxyV2Handler(instance);
                    AddServices(browserActionsStorage);
                    AddVPNService(browserActionsStorage, vpn);

                    browserActionsStorage.ExecuteActions(BrowserProjectActions.SelectionSession);
                }
                catch (Exception ex)
                {
                    isGoodEnd = false;
                    ErrorMessage errorMessage = new FileErrorMessageBuilder(ex, guid.ToString());
                    config.Logger.WriteError(errorMessage);
                }
                finally
                {
                    BrowserConfig.Instance.ResetBrowserProperies();
                    if(isGoodEnd)
                    {
                        InfoMessage message = new FileInfoMessageBuilder($"Guid: {guid} выполнен успешно.");
                        config.Logger.WriteInfo(message);
                    }
                    else
                    {
                        InfoMessage message = new FileInfoMessageBuilder($"Guid: {guid} завершился с ошибкой.");
                        config.Logger.WriteInfo(message);
                    }
                }

                int executionResult = 0;
                return executionResult;
            }
        }

        private void AddServices(BrowserActionsManager browserActionsStorage)
        {
            browserActionsStorage.AddService(BrowserProjectActions.SelectionSession, () => new AccountSelectionFormBrowserAction());
            browserActionsStorage.AddService(BrowserProjectActions.OpenMenu, () => new MainMenuFormBrowserAction(_instance));
            browserActionsStorage.AddService(BrowserProjectActions.OpenBookmarkMenu, () => new BookmarksFormAction());
            browserActionsStorage.AddService(BrowserProjectActions.AddNewAccount, () => new AccountCreatorFormBrowserAction(_project));

            var sessionManager = new SessionManager(_project);
            browserActionsStorage.AddService(BrowserProjectActions.LoadingSession, sessionManager.LoadAccount);
            browserActionsStorage.AddLastServices(sessionManager.SaveAccount);

            var zennposterActionManager = new ZennoPosterBrowserManager(_instance);
            browserActionsStorage.AddService(BrowserProjectActions.BrowserWaitUserAction, zennposterActionManager.WaitUserAction);
        }

        private void AddVPNService(BrowserActionsManager browserActionsStorage, IVPN VPNService)
        {
            var settings = BaseConfig.Instance.ProjectSettingsLoader.ProjectSettings;
            if (settings.IsEnableVPN)
            {
                if (VPNService is IProxyActions proxyActions)
                {
                    browserActionsStorage.AddService(BrowserProjectActions.UpdateProxy, () => new InstanceProxyUpdater(proxyActions));
                }
                browserActionsStorage.AddFirstServices(VPNService.TurnOnProxy);
                browserActionsStorage.AddLastServices(VPNService.TurnOffProxy);
            }

        }
    }
}