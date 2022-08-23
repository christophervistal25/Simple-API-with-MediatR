using App.Domain.Entities;
using Mapster;

namespace App.Core.StudentModule.Transports;

public class StudentTransport:BaseTransport, IRegister
{
    public string FirstName { get; set; }
    public string? MiddleName { get; set; }
    public string LastName { get; set; }
    
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Student, StudentTransport>();
        config.NewConfig<StudentTransport, Student>();
    }
}