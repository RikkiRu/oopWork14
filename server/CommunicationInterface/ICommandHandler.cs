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
		GET_QUESTION,
		SET_ANSWER,
		GET_SOME_QUESTIONS,
		QUESTION_CHART,
		EFFICIENCY_CHART,
		REPORT
	}
	[ServiceContract]
	public interface ICommandHandler {
		[OperationContract]
		object GetCommandString(Commands query, string data = null);
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
        QA getNewQA(int YourID);
        [OperationContract]
        string answerQA(QA question);
		[OperationContract]
		Dictionary<string, string> getThemePopularity();
	}
}
