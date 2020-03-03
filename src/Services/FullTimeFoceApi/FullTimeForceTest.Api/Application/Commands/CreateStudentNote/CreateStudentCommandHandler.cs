using FulltimeForceTest.Domain.StudentAggregate;
using FullTimeForceTest.Api.Infrastructure.Repository;
using FullTimeForceTest.Api.Infrastructure.Utility.Constants;
using FullTimeForceTest.Api.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FullTimeForceTest.Api.Application.Commands.CreateStudentNote
{
    public class CreateStudentCommandHandler
        : IRequestHandler<CreateStudentCommand, CalculateFinalNoteResponse>
    {
        private IApplicationRepository _applicationRepository;

        public CreateStudentCommandHandler(
            IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        public async Task<CalculateFinalNoteResponse> Handle(
            CreateStudentCommand request,
            CancellationToken cancellationToken)
        {
            var listNotes = request.Notes.Split(',');
            if (listNotes == null || listNotes.Length == 0) return new CalculateFinalNoteResponse();

            int TotalApproved = 0;
            int TotalNotApproved = 0;

            double SumNoteGeneral = 0;
            double SumNoteApproved = 0;
            double SumNoteNotApproved = 0;

            Student studentToCreate = null;
            foreach (var note in listNotes)
            {
                studentToCreate = new Student();
                try
                {
                    studentToCreate.Note = Convert.ToDouble(note);
                }
                catch (Exception)
                {
                    studentToCreate.Note = 0;
                }

                if (studentToCreate.Note > ValuesStudentNote.ApprovedNote)
                {
                    TotalApproved += 1;
                    SumNoteApproved += studentToCreate.Note;
                }
                else
                {
                    TotalNotApproved += 1;
                    SumNoteNotApproved += studentToCreate.Note;
                }
                SumNoteGeneral += studentToCreate.Note;

                _applicationRepository.CreateStudentNote(studentToCreate);
            }

            CalculateFinalNoteResponse finalResponse = new CalculateFinalNoteResponse();
            finalResponse.TotalApproved = TotalApproved;
            finalResponse.TotalNotApproved = TotalNotApproved;
            finalResponse.AverageNoteGeneral = (SumNoteGeneral / listNotes.Length);
            finalResponse.AverageNoteApproved = (SumNoteApproved / TotalApproved);
            finalResponse.AverageNoteNotApproved = (SumNoteNotApproved / TotalNotApproved);

            return finalResponse;
        }
    }
}
