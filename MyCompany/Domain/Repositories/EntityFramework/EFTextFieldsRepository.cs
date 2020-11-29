using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;

namespace MyCompany.Domain.Repositories.EntityFramework
{
    public class EFTextFieldsRepository : ITextFieldsRepository
    {
        private readonly AppDbContext _context;

        public EFTextFieldsRepository(AppDbContext context) => this._context = context;

        public IQueryable<TextField> GetTextFields() => _context.TextFields;

        public TextField GetTextFieldById(Guid id) => _context.TextFields.FirstOrDefault(x => x.Id == id);

        public TextField GetTextFieldByCodeWord(string codeword) => _context.TextFields.FirstOrDefault(x => x.CodeWord == codeword);

        public void SaveTextField(TextField entity)
        {
            _context.Entry(entity).State = entity.Id == default ? EntityState.Added : EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteTextField(Guid id)
        {
            _context.TextFields.Remove(new TextField() {Id = id});
            _context.SaveChanges();
        }
    }
}
