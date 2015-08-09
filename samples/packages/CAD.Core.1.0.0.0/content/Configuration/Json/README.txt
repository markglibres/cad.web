			this._jsonConfigFile = System.IO.Path.Combine(this.PluginDirectory,"config.json");

            _config = JsonFileManager.Instance.Deserialize<EpiServerConfig>(this._jsonConfigFile);

            _config.LastSyncId += 1;

            JsonFileManager.Instance.Serialize<EpiServerConfig>(this._jsonConfigFile, _config);

=============================================================================================================================
		private string _jsonConfigFile;
		private IJsonFile _jsonConfig;

        public ExhibitionImporter()
        {
            this._jsonConfigFile = System.IO.Path.Combine(this.PluginDirectory,"config.json");
            this._jsonConfig = JsonFileManager.Instance.Read(this._jsonConfigFile);

            //for testing
            if(this._jsonConfig != null)
            {
                //TO get value
                int lastId = this._jsonConfig.GetValue<int>("lastid");
                string connectionString = this._jsonConfig.GetValue<string>("connectionString");
                List<List<int>> testData = this._jsonConfig.GetValue<List<List<int>>>("testdata");
                Dictionary<string, object> _testing = this._jsonConfig.GetValue<Dictionary<string, object>>("testing");

                if (testData == null)
                    testData = new List<List<int>>();

                if (_testing == null)
                    _testing = new Dictionary<string, object>();

                testData.Add(new List<int>() { lastId + 3, lastId + 4 });
                testData.Add(new List<int>() { lastId + 5, lastId + 6 });

                if (!_testing.ContainsKey((lastId + 1).ToString()))
                    _testing.Add((lastId + 1).ToString(),lastId + 1);
                if (!_testing.ContainsKey((lastId + 2).ToString()))
                    _testing.Add((lastId + 2).ToString(), lastId + 2);

                Dictionary<string, object> _testing2 = new Dictionary<string, object>();
                _testing2.Add((lastId + 3).ToString() + "-1",(lastId + 3));
                _testing2.Add((lastId + 3).ToString() + "-2",(lastId + 3));

                if (!_testing.ContainsKey((lastId + 3).ToString()))
                    _testing.Add((lastId + 3).ToString(), _testing2);

                //OR
                string test = this._jsonConfig.GetValue("lastid");

                //To SET value
                this._jsonConfig.SetValue<int>("lastid", lastId+1);
                //OR
                this._jsonConfig.SetValue("lastid", lastId + 3);
                this._jsonConfig.SetValue<List<List<int>>>("testdata", testData);
                this._jsonConfig.SetValue<Dictionary<string, object>>("testing", _testing);



                JsonFileManager.Instance.Write(this._jsonConfigFile, this._jsonConfig);
            }
        }

======================================================================================================