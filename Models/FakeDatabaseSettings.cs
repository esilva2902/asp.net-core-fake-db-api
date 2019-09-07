namespace FakeDbApi.Models {
    public class FakeDatabaseSettings : IFakeDatabaseSettings {
        public string EmployeeCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IFakeDatabaseSettings {
        string EmployeeCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}