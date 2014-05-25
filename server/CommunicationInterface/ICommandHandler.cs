using System.ServiceModel;
using CommunicationInterface;
using CommandsLib;
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
		[OperationContract]
		List<Consulters> getConsulters();
		[OperationContract]
		List<FAQ> getFAQ();
		[OperationContract]
		List<Themes> getThemes();
		[OperationContract]
		List<Tarif> getTarifs();

		[OperationContract]
		void addConsulter(Consulters consulter);
		[OperationContract]
		void addFAQ(FAQ faq);
		[OperationContract]
		void addTheme(Themes theme);
		[OperationContract]
		void addTarif(Tarif tarif);
		[OperationContract]

		void deleteConsulter(Consulters consulter);
		[OperationContract]
		void deleteFAQ(FAQ faq);
		[OperationContract]
		void deleteTheme(Themes theme);
		[OperationContract]
		void deleteTarif(Tarif tarif);

		[OperationContract]
		void editConsulter(Consulters consulter);
		[OperationContract]
		void editFAQ(FAQ faq);
		[OperationContract]
		void editTheme(Themes theme);
		[OperationContract]
		void editTarif(Tarif tarif);
		/*[OperationContract]
		void addItem(Table item);*/
        [OperationContract]
        QA getNewQA(int YourID);
        [OperationContract]
        string answerQA(QA x);
	}
}
