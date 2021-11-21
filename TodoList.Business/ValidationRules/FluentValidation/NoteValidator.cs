using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TodoList.Entities.Concrete;

namespace TodoList.Business.ValidationRules.FluentValidation
{
    public class NoteValidator:AbstractValidator<Note>
    {
        public NoteValidator()
        {
            RuleFor(n => n.TaskTitle).NotEmpty();
            RuleFor(n => n.TaskTitle).Length(2,30);
            RuleFor(n => n.TaskDescription).NotEmpty();
            RuleFor(n => n.TaskStartDate).NotEmpty();
            RuleFor(n => n.TaskEndDate).NotEmpty();

        }
    }
}
