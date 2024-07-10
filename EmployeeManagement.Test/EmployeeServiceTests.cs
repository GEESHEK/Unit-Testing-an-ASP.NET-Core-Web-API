using EmployeeManagement.Business;
using EmployeeManagement.Test.Services;

namespace EmployeeManagement.Test;

public class EmployeeServiceTests
{
    [Fact]
    public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithObject()
    {
        // Arrange
        var employeeManagementTestDataRepository =
            new EmployeeManagementTestDataRepository();
        var employeeService = new EmployeeService(
            employeeManagementTestDataRepository,
            new EmployeeFactory());
        var obligatoryCourse = employeeManagementTestDataRepository
            .GetCourse(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

        // Act
        var internalEmployee = employeeService
            .CreateInternalEmployee("Brooklyn", "Cannon");

        // Assert
        Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);
    }

    [Fact]
    public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_WithPredicate()
    {
        // Arrange
        var employeeManagementTestDataRepository =
            new EmployeeManagementTestDataRepository();
        var employeeService = new EmployeeService(
            employeeManagementTestDataRepository,
            new EmployeeFactory());

        // Act
        var internalEmployee = employeeService
            .CreateInternalEmployee("Brooklyn", "Cannon");

        // Assert
        Assert.Contains(internalEmployee.AttendedCourses,
            course => course.Id == Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));
    }
    
    [Fact]
    public void CreateInternalEmployee_InternalEmployeeCreated_AttendedCoursesMustNotBeNew()
    {
        // Arrange
        var employeeManagementTestDataRepository =
            new EmployeeManagementTestDataRepository();
        var employeeService = new EmployeeService(
            employeeManagementTestDataRepository,
            new EmployeeFactory());

        // Act
        var internalEmployee = employeeService
            .CreateInternalEmployee("Brooklyn", "Cannon");

        // Assert
        // foreach (var course in internalEmployee.AttendedCourses)
        // {
        //     Assert.False(course.IsNew);
        // }
        Assert.All(internalEmployee.AttendedCourses,
            course => Assert.False(course.IsNew));
    }
    
    [Fact]
    public async Task CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedFirstObligatoryCourse_Async()
    {
        // Arrange
        var employeeManagementTestDataRepository =
            new EmployeeManagementTestDataRepository();
        var employeeService = new EmployeeService(
            employeeManagementTestDataRepository,
            new EmployeeFactory());
        var obligatoryCourse = await employeeManagementTestDataRepository
            .GetCourseAsync(Guid.Parse("37e03ca7-c730-4351-834c-b66f280cdb01"));

        // Act
        var internalEmployee = await employeeService
            .CreateInternalEmployeeAsync("Brooklyn", "Cannon");

        // Assert
        Assert.Contains(obligatoryCourse, internalEmployee.AttendedCourses);
    }
}