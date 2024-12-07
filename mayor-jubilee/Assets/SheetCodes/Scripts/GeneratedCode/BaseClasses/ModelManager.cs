using System;
using System.Collections.Generic;
using UnityEngine;

namespace SheetCodes
{
	//Generated code, do not edit!

	public static class ModelManager
	{
        private static Dictionary<DatasheetType, LoadRequest> loadRequests;

        static ModelManager()
        {
            loadRequests = new Dictionary<DatasheetType, LoadRequest>();
        }

        public static void InitializeAll()
        {
            DatasheetType[] values = Enum.GetValues(typeof(DatasheetType)) as DatasheetType[];
            foreach(DatasheetType value in values)
                Initialize(value);
        }
		
        public static void Unload(DatasheetType datasheetType)
        {
            switch (datasheetType)
            {
                case DatasheetType.Characters:
                    {
                        if (charactersModel == null || charactersModel.Equals(null))
                        {
                            Log(string.Format("Sheet Codes: Trying to unload model {0}. Model is not loaded.", datasheetType));
                            break;
                        }
                        Resources.UnloadAsset(charactersModel);
                        charactersModel = null;
                        LoadRequest request;
                        if (loadRequests.TryGetValue(DatasheetType.Characters, out request))
                        {
                            loadRequests.Remove(DatasheetType.Characters);
                            request.resourceRequest.completed -= OnLoadCompleted_CharactersModel;
							foreach (Action<bool> callback in request.callbacks)
								callback(false);
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        public static void Initialize(DatasheetType datasheetType)
        {
            switch (datasheetType)
            {
                case DatasheetType.Characters:
                    {
                        if (charactersModel != null && !charactersModel.Equals(null))
                        {
                            Log(string.Format("Sheet Codes: Trying to Initialize {0}. Model is already initialized.", datasheetType));
                            break;
                        }

                        charactersModel = Resources.Load<CharactersModel>("ScriptableObjects/Characters");
                        LoadRequest request;
                        if (loadRequests.TryGetValue(DatasheetType.Characters, out request))
                        {
                            Log(string.Format("Sheet Codes: Trying to initialize {0} while also async loading. Async load has been canceled.", datasheetType));
                            loadRequests.Remove(DatasheetType.Characters);
                            request.resourceRequest.completed -= OnLoadCompleted_CharactersModel;
							foreach (Action<bool> callback in request.callbacks)
								callback(true);
                        }
                        break;
                    }
                default:
                    break;
            }
        }

        public static void InitializeAsync(DatasheetType datasheetType, Action<bool> callback)
        {
            switch (datasheetType)
            {
                case DatasheetType.Characters:
                    {
                        if (charactersModel != null && !charactersModel.Equals(null))
                        {
                            Log(string.Format("Sheet Codes: Trying to InitializeAsync {0}. Model is already initialized.", datasheetType));
                            callback(true);
                            break;
                        }
                        if(loadRequests.ContainsKey(DatasheetType.Characters))
                        {
                            loadRequests[DatasheetType.Characters].callbacks.Add(callback);
                            break;
                        }
                        ResourceRequest request = Resources.LoadAsync<CharactersModel>("ScriptableObjects/Characters");
                        loadRequests.Add(DatasheetType.Characters, new LoadRequest(request, callback));
                        request.completed += OnLoadCompleted_CharactersModel;
                        break;
                    }
                default:
                    break;
            }
        }

        private static void OnLoadCompleted_CharactersModel(AsyncOperation operation)
        {
            LoadRequest request = loadRequests[DatasheetType.Characters];
            charactersModel = request.resourceRequest.asset as CharactersModel;
            loadRequests.Remove(DatasheetType.Characters);
            operation.completed -= OnLoadCompleted_CharactersModel;
            foreach (Action<bool> callback in request.callbacks)
                callback(true);
        }

		private static CharactersModel charactersModel = default;
		public static CharactersModel CharactersModel
        {
            get
            {
                if (charactersModel == null)
                    Initialize(DatasheetType.Characters);

                return charactersModel;
            }
        }
		
        private static void Log(string message)
        {
            Debug.LogWarning(message);
        }
	}
	
    public struct LoadRequest
    {
        public readonly ResourceRequest resourceRequest;
        public readonly List<Action<bool>> callbacks;

        public LoadRequest(ResourceRequest resourceRequest, Action<bool> callback)
        {
            this.resourceRequest = resourceRequest;
            callbacks = new List<Action<bool>>() { callback };
        }
    }
}
