using DomainLayer.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DomainLayer.DomainModelUnitOfWork
{
    public class UnitOfWork
    {
        private List<Customer> newObjects = new List<Customer>();
        private List<Customer> dirtyObjects = new List<Customer>();
        private List<Customer> removedObjects = new List<Customer>();

        private static ThreadLocal<UnitOfWork> threadLocal = new ThreadLocal<UnitOfWork>();

        public UnitOfWork()
        {
            threadLocal.Value = new UnitOfWork();
        }

        public static UnitOfWork getCurrent()
        {
            if (!threadLocal.IsValueCreated)
                new UnitOfWork();
            return threadLocal.Value;
        }

        public void registerNew()
        {

        }

        public void registerDirty()
        {

        }

        public void registerRemove()
        {

        }

        public void Commit()
        {
            // insert new
            // update dirty
            // delete removed
        }

        public void Rollback()
        {
            // clear all ques
        }

    }
}
