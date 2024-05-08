using Data;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ResultDataCollection", menuName = "Test/ResultDataCollection")]
public class ResultDataCollection : ScriptableObjectSingleton<ResultDataCollection> {

    [SerializeField]
    private ResultData[] _resultsData;
    public ResultData[] ResultsData => _resultsData;

    public ResultData GetResultData(string id) {
        return _resultsData.FirstOrDefault(resultData => resultData.Id == id);
    }
}
