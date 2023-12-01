using System;
using System.Collections.Generic;
using AutoMapper;
using Bfour.Core.Entities;
using Bfour.Core.Repository;
using Bfour.Core.ResultModel;
using Bfour.Core.Services;
using Bfour.Core.UnitOfWorks;
using Bfour.Repository.Repository;

namespace Bfour.Service.Service
{
    public class MemberAppointmentService : Service<MemberAppointment>,IMemberAppointmentService
    {
        public readonly IMemberAppointmentRepository _memberAppointmentRepository;
        private readonly IMapper _mapper;
        public MemberAppointmentService(IGenericRepository<MemberAppointment> repository, IUnitOfWorks unitOfWorks,
            IMemberAppointmentRepository memberAppointmentRepository, IMapper mapper) : base(repository, unitOfWorks)
        {
            _mapper = mapper;
            _memberAppointmentRepository = memberAppointmentRepository;
        }

        public async Task<Result<IEnumerable<MemberAppointment>>> GetMemberAppointmentAllAsync()
        {
            var memberAppointment = await _memberAppointmentRepository.GetMemberAppointmentsAsync();
            return Result<IEnumerable<MemberAppointment>>.Success(200, memberAppointment, true);
        }

        public Result<MemberAppointment> GetMemberAppointmentById(int id)
        {
            var memberAppointment = _memberAppointmentRepository.Where(x => x.Id == id).FirstOrDefault();

            return Result<MemberAppointment>.Success(200, memberAppointment, true);
        }
    }
}

