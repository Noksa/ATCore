﻿using System.Collections.Generic;
using System.Threading;
using AT_Core_Specflow.Core;
using AT_Core_Specflow.Extensions;
using TechTalk.SpecFlow;

namespace AT_Core_Specflow.Hooks
{
    [Binding]
    public class CoreSteps
    {
        #region Fields

        private static readonly ThreadLocal<ScenarioContext> ScenarioContextThreadLocal = new ThreadLocal<ScenarioContext>();

        #endregion

        #region Properties

        public static ScenarioContext ScenarioContext => ScenarioContextThreadLocal.Value;

        #endregion

        #region Ctor

        public CoreSteps(ScenarioContext scenarioContext)
        {
            ScenarioContextThreadLocal.Value = scenarioContext;
            CommonExtension.AddCommonVariablesToContext();
        }

        #endregion

        #region Actions in pages

        [StepDefinition(@"открывается страница ""(.*)""")]
        public void OpenPage(string pageTitle)
        {
            PageManager.PageContext.OpenPage(pageTitle);
        }

        [StepDefinition("^пользователь \\((.*)\\)$")]
        public void ExecuteMethodByTitle(string actionTitle)
        {
            PageManager.PageContext.CurrentPage.ExecuteMethodByTitle(actionTitle);
        }

        [StepDefinition("^пользователь \\((.*)\\) \"([^\"]*)\"$")]
        public void ExecuteMethodByTitle(string actionTitle, string param1)
        {
            PageManager.PageContext.CurrentPage.ExecuteMethodByTitle(actionTitle, param1);
        }

        [StepDefinition("^пользователь \\((.*)\\) \"([^\"]*)\" (?:значением |со значением |с параметром | |)\"([^\"]*)\"$")]
        public void ExecuteMethodByTitle(string actionTitle, Transforms.WrappedString param1, Transforms.WrappedString param2)
        {
            PageManager.PageContext.CurrentPage.ExecuteMethodByTitle(actionTitle, param1.Value, param2.Value);
        }

        [StepDefinition("^пользователь \\((.*)\\) \"([^\"]*)\" (?:значениями |со значениями |с параметрами | |)\"([^\"]*)\" \"([^\"]*)\"$")]
        public void ExecuteMethodByTitle(string actionTitle, Transforms.WrappedString param1, Transforms.WrappedString param2, Transforms.WrappedString param3)
        {
            PageManager.PageContext.CurrentPage.ExecuteMethodByTitle(actionTitle, param1.Value, param2.Value, param3.Value);
        }

        [StepDefinition("^пользователь \\((.*)\\) из списка$")]
        public void ExecuteMethodByTitle(string actionTitle, List<object> list)
        {
            PageManager.PageContext.CurrentPage.ExecuteMethodByTitle(actionTitle, list);
        }

        [StepDefinition("^пользователь \\((.*)\\) из таблицы$")]
        public void ExecuteMethodByTitle(string actionTitle, Dictionary<string, string> dict)
        {
            PageManager.PageContext.CurrentPage.ExecuteMethodByTitle(actionTitle, dict);
        }

        #endregion

        #region Actions in blocks

        [StepDefinition("^пользователь в блоке \"([^\"]*)\" \\((.*)\\) \"([^\"]*)\"$")]
        public void ExecuteMethodByTitleInBlock(string blockName, string actionTitle, string elementTitle)
        {
            PageManager.PageContext.CurrentPage.ExecuteMethodByTitleInBlock(blockName, actionTitle, elementTitle);
        }

        [StepDefinition("^пользователь в блоке \"([^\"]*)\" \\((.*)\\) \"([^\"]*)\" (?:значением |со значением |с параметром | |)\"([^\"]*)\"$")]
        public void ExecuteMethodByTitleInBlock(string blockName, string actionTitle, string elementTitle, Transforms.WrappedString param1)
        {
            PageManager.PageContext.CurrentPage.ExecuteMethodByTitleInBlock(blockName, actionTitle, elementTitle, param1.Value);
        }

        [StepDefinition("^пользователь в блоке \"([^\"]*)\" \\((.*)\\) \"([^\"]*)\" (?:с значениями |со значениями |с параметрами | |)\"([^\"]*)\" \"([^\"]*)\"$")]
        public void ExecuteMethodByTitleInBlock(string blockName, string actionTitle, string elementTitle, Transforms.WrappedString param1, Transforms.WrappedString param2)
        {
            PageManager.PageContext.CurrentPage.ExecuteMethodByTitleInBlock(blockName, actionTitle, elementTitle, param1.Value, param2.Value);
        }

        [StepDefinition("^пользователь в блоке \"([^\"]*)\" \\((.*)\\)$")]
        public void ExecuteMethodByTitleInBlock(string blockName, string actionTitle)
        {
            PageManager.PageContext.CurrentPage.ExecuteMethodByTitleInBlock(blockName, actionTitle);
        }

        #endregion

    }
}
