using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vizsgaremek.Models
{
    public enum EmploymentValue { LECTURER, INDENTUREDLABOURER, DONEONCOMMISSION }

    public class Teacher
    {
        private string id;
        private string lastName;
        private string firstName;
        private string password;
        private bool meal;
        private EmploymentValue emploeyment;
        private string emploeymentName;

        public Teacher()
        {
            {
                this.Id = string.Empty;
                this.LastName = string.Empty;
                this.FirstName = string.Empty;
                this.Password = string.Empty;
                this.Meal = false;
                this.Emploeyment = EmploymentValue.DONEONCOMMISSION;
            }
        }
        public Teacher(string id, string lastname, string firstname, string password, bool meal, EmploymentValue emploeyment)
        {
            this.id = id;
            this.lastName = lastname;
            this.FirstName = firstname;
            this.Password = password;
            this.Meal = meal;
            this.Emploeyment = emploeyment;
        }

        public string Id { get => id; set => id = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Password { get => password; set => password = value; }
        public bool Meal { get => meal; set => meal = value; }
        public EmploymentValue Emploeyment { get => emploeyment; set => emploeyment = value; }
        public string EmploeymentName { get => emploeymentName; set => emploeymentName = value; }
    }
