using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FakeDbApi.Models {
  public class Employee {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string employeeId { get; set; }

        [BsonElement("firstName")]
        public string EmployeeFirstName { get; set; }

        public string lastName { get; set; }

        public string secondLastName { get; set; }

        public string gender { get; set; }

        public int age { get; set; }

        public string email { get; set; }

        public string phoneNumber { get; set; }

        public object address { get; set; }

        public bool active { get; set; }

        public int __v { get; set; }
    }
}