namespace Task6_PatternCommandCars
{
    /// <summary>
    /// base class for command
    /// </summary>
    class Command : ICommand
    {
        ICommand icommand { get; set; }
        /// <summary>
        /// set icommand
        /// </summary>
        public Command(ICommand icommand)
        {
            this.icommand = icommand;
        }
        public string Execute()
        {
            return icommand.Execute();
        }
    }
}
