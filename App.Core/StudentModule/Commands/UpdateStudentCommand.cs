using App.Core.Contracts;
using App.Core.StudentModule.Transports;
using Mapster;
using MapsterMapper;
using MediatR;

namespace App.Core.StudentModule.Commands
{
    public class UpdateStudentCommand :IRequest<StudentTransport>
    {
        public StudentTransport StudentTransport { get; set; }
    }



    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, StudentTransport>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;


        public UpdateStudentCommandHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        public async Task<StudentTransport> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _context.Student.FindAsync(request.StudentTransport.Id);
            
            request.StudentTransport.Adapt(student);

            await _context.SaveChangesAsync(cancellationToken);

            return request.StudentTransport;
        }
    }
}

