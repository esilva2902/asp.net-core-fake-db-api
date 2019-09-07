using FakeDbApi.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace FakeDbApi.Services {
    public class EmployeeService {
        private readonly IMongoCollection<Employee> employee;

        public EmployeeService(IFakeDatabaseSettings settings) {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            this.employee = database.GetCollection<Employee>(settings.EmployeeCollectionName);
        }

        public List<Employee> Get() =>
            this.employee.Find(employee => true).ToList();

        public List<Employee> Get(int pageNumber, int pageSize) {
            return this.employee.Find(employee => true)
                .Skip((pageNumber - 1) * pageSize)
                .Limit(pageSize)
                .ToList();
        }

        public Employee Get(string id) =>
            this.employee.Find<Employee>(employee => employee.Id == id).FirstOrDefault();

        public Employee Create(Employee employee) {
            this.employee.InsertOne(employee);
            return employee;
        }

        public void Update(string id, Employee employeeIn) =>
            this.employee.ReplaceOne(employee => employee.Id == id, employeeIn);

        public void Remove(Employee employeeIn) =>
            this.employee.DeleteOne(employee => employee.Id == employeeIn.Id);

        public void Remove(string id) => 
            this.employee.DeleteOne(employee => employee.Id == id);
    }
}