﻿using Biblioteca_REST_API.Models;
using Biblioteca_REST_API.Models.Context;

namespace Biblioteca_REST_API.Repository.Implementations
{
    public class PersonRepositoryImplementation : IRepository
    {
        private MySQLContext _context;

        public PersonRepositoryImplementation(MySQLContext context)
        {
            _context = context;
        }

        public T Create(T person)
        {
            try
            {
                _context.Persons.Add(person);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return person;
        }

        public T Update(T person)
        {
            if (!Exists(person.Id)) return null;
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(person.Id));
            if (result is not null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
            if (result is not null)
            {
                try
                {
                    _context.Persons.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        public List<T> FindAll()
        {
            return _context.Persons.ToList();
        }

        public T FindById(long id)
        {
            return _context.Persons.SingleOrDefault(p => p.Id.Equals(id));
        }

        public bool Exists(long id)
        {
            return _context.Persons.Any(p => p.Id.Equals(id));
        }
    }
}
