using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FITHAUI.ATMSystem
{
    public class History
    {
        List<Log> logs { get; set; }
        List<ATM> aTMs { get; set; }
        List<LogType> logTypes { get; set; }
        public History(List<Log> logs, List<ATM> aTMs, List<LogType> logTypes)
        {
            this.logs = logs;
            this.aTMs = aTMs;
            this.logTypes = logTypes;
        }
    }
}
