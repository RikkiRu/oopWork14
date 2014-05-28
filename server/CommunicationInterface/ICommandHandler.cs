using System.ServiceModel;
using CommunicationInterface;
using dbLib;
using System.Collections;
using System;
using System.Collections.Generic;

namespace CommunicationInterface {
	public enum Commands {
		LOGIN,
		ADD_CONSULTER,
		EDIT_CONSULTER,
		SHOW_CONSULTER,
		ADD_FAQ,
		EDIT_FAQ,
		SHOW_FAQ,
		ADD_THEME,
		EDIT_THEME,
		SHOW_THEME,
		ADD_TARIF,
		EDIT_TARIF,
		SHOW_TARIF,
		SHOW_QA,
		GET_QUESTION,
		SET_ANSWER,
		GET_SOME_QUESTIONS,
		QUESTION_CHART,
		EFFICIENCY_CHART,
		REPORT,
        SHOW_SALARY
	}
	[ServiceContract]
	public interface ICommandHandler {
		[OperationContract]
		Consulters Login(Consulters consulter);
        [OperationContract]
        string getFirmInfo();
		/* Idk how to make this work, but its awesome!
		 * [OperationContract]
		List<T> getTable<T>() where T : Table;*/
		/* Get */
		[OperationContract]
		List<Consulters> getConsulters();
		[OperationContract]
		List<FAQ> getFAQ();
		[OperationContract]
		List<Themes> getThemes();
		[OperationContract]
		List<Tarif> getTarifs();
		[OperationContract]
		List<consulter_salary> getSalary();
		/* Add */
		[OperationContract]
		string addConsulter(Consulters consulter);
		[OperationContract]
		string addFAQ(FAQ faq);
		[OperationContract]
		string addTheme(Themes theme);
		[OperationContract]
		string addTarif(Tarif tarif);
		[OperationContract]
		/* Delete */
		string deleteConsulter(Consulters consulter);
		[OperationContract]
		string deleteFAQ(FAQ faq);
		[OperationContract]
		string deleteTheme(Themes theme);
		[OperationContract]
		string deleteTarif(Tarif tarif);
		/* Edit */
		[OperationContract]
		string editConsulter(Consulters consulter);
		[OperationContract]
		string editFAQ(FAQ faq);
		[OperationContract]
		string editTheme(Themes theme);
		[OperationContract]
		string editTarif(Tarif tarif);
		/*[OperationContract]
		void addItem(Table item);*/
		/* Functions */
		[OperationContract]
		QA getNewQA(int YourID, int startQuestionID = 0, bool isBinded = false);
		[OperationContract]
		string answerQA(QA question);
		[OperationContract]
		Dictionary<string, string> getThemePopularity();
		[OperationContract]
		object getReport();
		[OperationContract]
		Dictionary<string, string> getEfficiencyChart();
		//все вопросы и какие-либо похожие (true -> с похожими вопросами, иначе с похожими ответами) UPD шта?
		[OperationContract]
		List<QA> getAllQA();
		[OperationContract]
		List<QA> getSimilarQA(QA source, bool IsQuestions);
		[OperationContract]
		string bindQuestion(QA question, int consulterID);
	}
}
