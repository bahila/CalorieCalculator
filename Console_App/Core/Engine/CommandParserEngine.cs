﻿using System;
using Console_App.Core.Contracts;
using Console_App.Core.Providers;

namespace Console_App.Core.Engine
{
    public class CommandParserEngine : ICommandParserEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";
        private static CommandParserEngine instanceHolder;

        public CommandParserEngine()
        {
            this.Reader = new ConsoleReader();
            this.Writer = new ConsoleWriter();
            this.Parser = new CommandParser();
        }

        public static CommandParserEngine Instance
        {
            get
            {
                if (instanceHolder == null)
                {
                    instanceHolder = new CommandParserEngine();
                }

                return instanceHolder;
            }
        }

        public IReader Reader { get; set; }
        public IWriter Writer { get; set; }
        public IParser Parser { get; set; }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.Reader.ReadLine();

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.Writer.WriteLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            if (string.IsNullOrWhiteSpace(commandAsString))
            {
                throw new ArgumentNullException("Command cannot be null or empty.");
            }

            var command = this.Parser.ParseCommand(commandAsString);
            var parameters = this.Parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);
            this.Writer.WriteLine(executionResult);
        }
    }
}