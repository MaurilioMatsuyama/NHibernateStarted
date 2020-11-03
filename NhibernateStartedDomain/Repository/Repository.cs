using NHibernate;
using NhibernateStarted.Repository;
using NhibernateStartedDomain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NhibernateStartedDomain.Repository
{
    public class Repository<T> : IRepository<T> where T : IEntity
    {
        private readonly ISessionFactory _sessionFactory;

        public Repository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public void Post(T entidade)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entidade);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if(!transaction.WasCommitted)
                        {
                            transaction.Rollback();
                        }
                        throw new Exception("Erro ao inserir a entidade :" + ex.Message);
                    }
                }
            }
        }

        public void Put(T entidade)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entidade);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasCommitted)
                        {
                            transaction.Rollback();
                        }
                        throw new Exception("Erro ao atualizar a entidade :" + ex.Message);
                    }
                }
            }
        }

        public void Delete(T entidade)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entidade);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transaction.WasCommitted)
                        {
                            transaction.Rollback();
                        }
                        throw new Exception("Erro ao excluir a entidade :" + ex.Message);
                    }
                }
            }
        }

        public T Get(long id)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                return session.Get<T>(id);
            }
        }

        public List<T> GetAll()
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> where)
        {
            using (ISession session = _sessionFactory.OpenSession())
            {
                return session.Query<T>().Where(where).ToList();
            }
        }
    }
}
