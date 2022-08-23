using App.Core.Contracts;
using App.Core.StudentModule.Transports;
using App.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace App.Core.StudentModule.Commands
{
    /// <summary>
    /// IRequest<>
    /// ang luon sa sulod ng generic na IRequest
    /// kay kung uno'y imoo gusto na return
    /// </summary>
    public class AddStudentCommand :IRequest<StudentTransport>
    {
        public StudentTransport StudentTransport { get; set; }
    }
    
    /// <summary>
    /// Require gaud ni IRequestHandler na ang ipasa
    /// mo sa First argument ng IRequestHandler na generic
    /// kay ang Command then ang sunod kay ang next gusto mo
    /// na i-return o Return Type nea.
    /// </summary>
    public class AddStudentCommandHandler : IRequestHandler<AddStudentCommand, StudentTransport>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;


        public AddStudentCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentTransport> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request.StudentTransport);
            
            var result = await _context.Student.AddAsync(student);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            request.StudentTransport.Id = result.Entity.Id;
            
            return request.StudentTransport;
        }
    }
}
