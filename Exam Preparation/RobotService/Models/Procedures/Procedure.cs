using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using RobotService.Models.Procedures.Contracts;
using RobotService.Models.Robots.Contracts;
using RobotService.Utilities.Messages;

namespace RobotService.Models.Procedures
{
    public abstract class Procedure : IProcedure
    {
        protected Procedure()
        {
            this.Robots = new List<IRobot>();
        }

        protected IList<IRobot> Robots { get; }

        public string History()
        {
            var sb = new StringBuilder();
            sb.AppendLine(this.GetType().Name);

            foreach (var robot in this.Robots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public virtual void DoService(IRobot robot, int procedureTime)
        {
            if (robot.ProcedureTime < procedureTime)
            {
                throw new ArgumentException(ExceptionMessages.InsufficientProcedureTime);
            }
            
        }
    }
}