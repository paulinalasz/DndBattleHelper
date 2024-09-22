using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DndBattleHelper.Models
{
    public interface IEntity
    {
        public string Name { get; set; }
        public int Health { get; set; }
    }
}
