using App.Core.Contracts;
using App.Core.StudentModule.Transports;
using App.Domain.Entities;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace App.Core.StudentModule.Queries
{
    /// <summary>
    /// IRequest<>
    /// ang luon sa sulod ng generic na IRequest
    /// kay kung uno'y imoo gusto na return
    /// </summary>
    public class GetAllStudentQuery :IRequest<List<StudentTransport>>
    {
        
    }

    // <summary>
    /// Require gaud ni IRequestHandler na ang ipasa
    /// mo sa First argument ng IRequestHandler na generic
    /// kay ang Command then ang sunod kay ang next gusto mo
    /// na i-return o Return Type nea.
    /// </summary>
    public class GetAllStudentHandler : IRequestHandler<GetAllStudentQuery, List<StudentTransport>>
    {
        private readonly IAppDbContext _context;
        private readonly IMapper _mapper;

        public GetAllStudentHandler(IAppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<StudentTransport>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            var students = await _context.Student.ToListAsync();
            return _mapper.Map <List<Student>, List<StudentTransport>>(students);
        }
    }
    
    
}
