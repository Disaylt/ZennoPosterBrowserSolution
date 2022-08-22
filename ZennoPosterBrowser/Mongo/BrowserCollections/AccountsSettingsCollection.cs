﻿using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZennoPosterBrowser.Models.BSON;

namespace ZennoPosterBrowser.Mongo.BrowserCollections
{
    internal class AccountsSettingsCollection : BrowserDatabaseConnector, IMongoCollectionConnector<AccountsSettingsModel>
    {
        private const string _collectionName = "AccountsSettings";

        public AccountsSettingsCollection()
        {
            Collection = DataBase.GetCollection<AccountsSettingsModel>(_collectionName);
            AccountsSettings = LoadAccountsSettings();
        }

        public IEnumerable<AccountsSettingsModel> AccountsSettings { get; }
        public IMongoCollection<AccountsSettingsModel> Collection { get; }

        private IEnumerable<AccountsSettingsModel> LoadAccountsSettings()
        {
            IEnumerable<AccountsSettingsModel> accountsSettings = Collection
                .Find(new BsonDocument())
                .ToList();
            return accountsSettings;
        }
    }
}