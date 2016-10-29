using Project_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_Entity;
using Project_DAL;

namespace Project_BLL.Implementation
{
    public class EmlakTipService : IEmlakTipService
    {
        private readonly IRepository<EmlakTip> _emlakTipRepository;

        public EmlakTipService(IRepository<EmlakTip> emlakTipRepository)
        {
            _emlakTipRepository = emlakTipRepository;
        }

        public void ChangeStatus(int Id)
        {
            EmlakTip emlakTip = GetById(Id);
            if (emlakTip != null)
            {
                emlakTip.IsActive = !emlakTip.IsActive;
                _emlakTipRepository.Update(emlakTip);
            }
        }

        public void Create(EmlakTip model)
        {
            if (model != null)
            {
                _emlakTipRepository.Insert(model);
            }
        }

        public void DeleteById(int Id)
        {
            EmlakTip emlakTip = GetById(Id);
            if (emlakTip != null)
            {
                _emlakTipRepository.Delete(emlakTip);
            }
        }

        public void edit(EmlakTip model)
        {
            if (model != null)
            {
                _emlakTipRepository.Update(model);
            }
        }

        public IList<EmlakTip> GetAll()
        {
            return _emlakTipRepository.Table.Where(x => x.IsDelete == false).ToList();
        }

        public EmlakTip GetById(int Id)
        {
            return _emlakTipRepository.GetById(Id);
        }
    }
}
