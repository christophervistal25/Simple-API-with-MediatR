using App.Core.Contracts;
using App.Core.StudentModule.Transports;
using App.Domain.Entities;
using MapsterMapper;
using MediatR;

namespace App.Core.StudentModule.Queries
{
    /// <summary>
    /// IRequest<>
    /// ang luon sa sulod ng generic na IRequest
    /// kay kung uno'y imoo gusto na return
    /// </summary>
    public  class GetStudentQuery :IRequest<StudentTransport>
    {
        public int Id { get; }

        public GetStudentQuery(int id)
        {
            Id = id;
        }
    }
    
    // <summary>
    /// Require gaud ni IRequestHandler na ang ipasa
    /// mo sa First argument ng IRequestHandler na generic
    /// kay ang Command then ang sunod kay ang next gusto mo
    /// na i-return o Return Type nea.
    /// </summary>
    public class GetStudentHandler : IRequestHandler<GetStudentQuery, StudentTransport>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;


        public GetStudentHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentTransport> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var student = await _context.Student.FindAsync(request.Id);
            return _mapper.Map<StudentTransport>(student!);
        }
    }
}


