﻿using Biblioteca_REST_API.Models;

namespace Biblioteca_REST_API.Repository
{
    public interface IRepository
    {
        T Create(T person);
        T FindById(long id);
        List<T> FindAll();
        T Update(T person);
        void Delete(long id);
        bool Exists(long id);

    }
}
