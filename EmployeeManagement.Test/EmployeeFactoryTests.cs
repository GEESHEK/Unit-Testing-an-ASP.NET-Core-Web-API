using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test;

public class EmployeeFactoryTests
{
    [Fact]
    //name of method being tested_Scenario under which it's being tested_expected behavior
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
    {
        //Arrange: setting up the test
        var employeeFactory = new EmployeeFactory();
        
        //Act: executing the actual test
        var employee = (InternalEmployee)employeeFactory
            .CreateEmployee("Kevin", "Dockx");
        
        //Assert: verifying the executed action
        Assert.Equal(2500, employee.Salary);
    }
    
    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
    {
        //Arrange: setting up the test
        var employeeFactory = new EmployeeFactory();
        
        //Act: executing the actual test
        var employee = (InternalEmployee)employeeFactory
            .CreateEmployee("Kevin", "Dockx");
        
        //Assert: verifying the executed action
        Assert.True(employee.Salary is >= 2500 and <= 3500,
            "Salary not in acceptable range.");
    }
    
    [Fact]
    public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_AlternativeWay()
    {
        //Arrange: setting up the test
        var employeeFactory = new EmployeeFactory();
        
        //Act: executing the actual test
        var employee = (InternalEmployee)employeeFactory
            .CreateEmployee("Kevin", "Dockx");
        
        //Assert: verifying the executed action
        Assert.InRange(employee.Salary, 2500, 3500);
    }
    
    
}