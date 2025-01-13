﻿using Biblioteca_REST_API.Models;
using Biblioteca_REST_API.Models.Context;
using Biblioteca_REST_API.Repository;

namespace Biblioteca_REST_API.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository _repository;

        public PersonBusinessImplementation(IRepository repository)
        {
            _repository = repository;
        }

        public T Create(T person)
        {
            return _repository.Create(person);
        }

        public T Update(T person)
        {
            return _repository.Update(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<T> FindAll()
        {
            return _repository.FindAll();
        }

        public T FindById(long id)
        {
            return _repository.FindById(id);
        }
    }
}
