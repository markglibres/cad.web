Tenant current = TenantManager.Instance.Current;

            current.Name = "Default";

            var plugin2 = new TenantPlugin() { Name = "Plugin2", IsEnabled = false };
            plugin2.AddProperty<string>("mongoDB", "test2");
            plugin2.Priority = 2;

            var plugin3 = new TenantPlugin() { Name = "Plugin1", IsEnabled = true };
            plugin3.AddProperty<string>("mongoDB", "test3");
            plugin3.Priority = 1;

            current.AddPlugin(plugin2);
            current.AddPlugin(plugin3);

            TenantManager.Instance.Save(current);