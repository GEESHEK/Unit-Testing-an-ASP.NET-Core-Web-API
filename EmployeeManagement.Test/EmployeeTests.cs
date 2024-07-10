using EmployeeManagement.DataAccess.Entities;

namespace EmployeeManagement.Test;

public class EmployeeTests
{
    [Fact]
    public void EmployeesFullNamePropertyGetter_InputFirstNameAndName_FullNameIsConcatenation()
    {
        // Arrange 
        var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);
        
        // Act
        employee.FirstName = "Lucia";
        employee.LastName = "Shelton";
        
        // Assert
        Assert.Equal("Lucia Shelton", employee.FullName, ignoreCase: true);
    }
    
    [Fact]
    public void EmployeesFullNamePropertyGetter_InputFirstNameAndName_FullNameStartsWithTheFirstName()
    {
        // Arrange 
        var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);
        
        // Act
        employee.FirstName = "Lucia";
        employee.LastName = "Shelton";
        
        // Assert
        Assert.StartsWith(employee.FirstName, employee.FullName);
    }
    
    [Fact]
    public void EmployeesFullNamePropertyGetter_InputFirstNameAndName_FullNameEndsWithTheLastName()
    {
        // Arrange 
        var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);
        
        // Act
        employee.FirstName = "Lucia";
        employee.LastName = "Shelton";
        
        // Assert
        Assert.EndsWith(employee.LastName, employee.FullName);
    }
    
    [Fact]
    public void EmployeesFullNamePropertyGetter_InputFirstNameAndName_FullNameContainsPartOfConcatenation()
    {
        // Arrange 
        var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);
        
        // Act
        employee.FirstName = "Lucia";
        employee.LastName = "Shelton";
        
        // Assert
        Assert.Contains("ia Sh", employee.FullName);
    }
    
    [Fact]
    public void EmployeesFullNamePropertyGetter_InputFirstNameAndName_FullNameSoundsLikeConcatenation()
    {
        // Arrange 
        var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);
        
        // Act
        employee.FirstName = "Lucia";
        employee.LastName = "Shelton";
        
        // Assert
        Assert.Matches("Lu(c|s|z)ia Shel(t|d)on", employee.FullName);
    }
}