using Academy.AcademyDbContextFactory;
using Academy.Lib;
using Academy.Lib.Models;
using Common.Lib.Core;
using Common.Lib.Core.Context;
using Common.Lib.DAL.EFCore;
using Common.Lib.Infrastructure;
using System;

namespace Academy
{
    public class Bootstrapper
    {
        public IDependencyContainer Init()
        {
            var depCon = new SimpleDependencyContainer();

            RegisterRepositories(depCon);

            Entity.DepCon = depCon;

            return depCon;
        }

        public void RegisterRepositories(IDependencyContainer depCon)
        {
            var studentRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new EfCoreRepository<Student>(GetDbConstructor());
            });


            var subjectsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new EfCoreRepository<Subject>(GetDbConstructor());
            });

            var studentsubjectsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new EfCoreRepository<StudentSubject>(GetDbConstructor());
            });

            var examsRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new EfCoreRepository<Exam>(GetDbConstructor());
            });

            var studentsExamRepoBuilder = new Func<object[], object>((parameters) =>
            {
                return new EfCoreRepository<StudentExam>(GetDbConstructor());
            });

            depCon.Register<IRepository<Student>, EfCoreRepository<Student>>(studentRepoBuilder);

            depCon.Register<IRepository<Subject>, EfCoreRepository<Subject>>(subjectsRepoBuilder);

            depCon.Register<IRepository<StudentSubject>, EfCoreRepository<StudentSubject>>(studentsubjectsRepoBuilder);

            depCon.Register<IRepository<Exam>, EfCoreRepository<Exam>>(examsRepoBuilder);

            depCon.Register<IRepository<StudentExam>, EfCoreRepository<StudentExam>>(studentsExamRepoBuilder);
        }

        private static AcademyDbContext GetDbConstructor()
        {
            var factory = new AcademyContextFactory();
            return factory.CreateDbContext(null);
        }
    }
}
