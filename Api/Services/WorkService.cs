using Api.Context;
using Api.Models;
using Api.Models.DTO;
using Api.Models.Enum;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{

    public interface IWorkService
    {
        Task<bool> Add(WorkDTO model);
        Task<bool> Update(Guid id, WorkDTO model);
        Task<bool> ChangeState(Guid id, CompleteState state);
        Task<bool> Delete(Guid id);
        Task<WorkDTO> Get(Guid id);
        Task<List<Work>> GetAll(DateTime date,WorkPeriod period);
    }

    public class WorkService : IWorkService
    {

        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public WorkService(IMapper mapper,ApiContext context)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<bool> Add(WorkDTO model)
        {
            var work = _mapper.Map<Work>(model);

            await _context.Works.AddAsync(work);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> ChangeState(Guid id, CompleteState state)
        {
            var work = await _context.Works.SingleOrDefaultAsync(x => x.WorkId == id);

            if (work == null || work.CompleteState == state)
                return false;

            switch (state)
            {
                case CompleteState.Start:
                    if (work.CompleteState != CompleteState.New || work.CompleteState != CompleteState.Stop)
                        return false;
                    break;
                case CompleteState.Stop:
                    if (work.CompleteState != CompleteState.Start)
                        return false;
                    break;
                default:
                    break;
            }

            work.CompleteState = state;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {
            var work = await _context.Works.SingleOrDefaultAsync(x => x.WorkId == id);

            if (work == null)
                return false;

            _context.Works.Remove(work);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<WorkDTO> Get(Guid id) =>
             _mapper.Map<WorkDTO>(
                await _context
                       .Works
                       .AsNoTracking()
                       .SingleOrDefaultAsync(x => x.WorkId == id)
                );

        public async Task<List<Work>> GetAll(DateTime date, WorkPeriod period)
        {
            DateTime startDate = date, endDate = date;

            switch (period)
            {
                case WorkPeriod.Day:
                    endDate = endDate.AddDays(1);
                    break;
                case WorkPeriod.Week:
                    endDate = endDate.AddDays(7);
                    break;
                case WorkPeriod.Month:
                    startDate = new DateTime(date.Year, date.Month, 1);
                    endDate = startDate.AddMonths(1);
                    break;
                default:
                    break;
            }

            return await _context
                                 .Works
                                 .AsNoTracking()
                                 .Where(x =>
                                            x.Date >= startDate &&
                                            x.Date < endDate
                                        )
                                 .ToListAsync();
        }

        public async Task<bool> Update(Guid id, WorkDTO model)
        {
            var work = await _context.Works.SingleOrDefaultAsync(x => x.WorkId == id);

            if (work == null)
                return false;

            _mapper.Map(model, work);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
