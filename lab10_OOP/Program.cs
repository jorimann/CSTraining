using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10_OOP
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    enum EPosition: int {Employee, Manager, Top_Manager};
    public class Employee
    {
        private String _FirstName;
        private String _LastName;
        private String _ManagersName; //TODO: how to make a link to a exist item?
        private EPosition _Position;
        
        public Employee(String FirstName, String LastName, EPosition Position, String ManagersName){        
            _FirstName = FirstName;
            _LastName = LastName;
            _ManagersName = ManagersName;
            _Position = Position;
        }

        public void Print(){
            //switch (Position)
            //{
            //    case Position.Employee:
            //        Console.WriteLine("Name: {0} {1}; Position: {2}", FirstName, LastName, Position);
            //        break;
            //    case Position.Manager:
            //        break;
            //    case Position.Top_Manager:
            //        break;
        	}

    }

    public class Manager : Employee
    {
        private List<String> ListOfSubordinates;
        public void Print() { }
    }

    public class TopManager : Manager
    {
        public void Print() { }
    }

    public class OrgChart{
        private List<Employee> ListOfEmployees{get;}

        public Boolean AddNewEmployee(String FirstName, String LastName, EPosition Position, String ManagersName) { return false;}
        public Boolean DeleteEmployee(String LastName) { return false; }
        public Boolean FindEmployee(String LastName, out Employee emp) { emp = null; return false;}
    }
}
