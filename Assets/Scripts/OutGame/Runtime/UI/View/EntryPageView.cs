using Cysharp.Threading.Tasks;
using OutGame.Runtime.UI.Model;
using ScreenSystem.Page;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace OutGame.Runtime.UI.View
{
    public class EntryPageView : PageViewBase
    {
        [SerializeField] private TextMeshProUGUI messageText;
        [SerializeField] private Button nextPageButton;
        [SerializeField] private Button prevPageButton;
        [SerializeField] private Button nextPageNoStackButton;
        [SerializeField] private Button popAllButton;

        public IUniTaskAsyncEnumerable<AsyncUnit> OnNextPageButtonClickedAsync => nextPageButton.OnClickAsAsyncEnumerable();
        public IUniTaskAsyncEnumerable<AsyncUnit> OnPrevPageButtonClickedAsync => prevPageButton.OnClickAsAsyncEnumerable();
        public IUniTaskAsyncEnumerable<AsyncUnit> OnNextPageNoStackButtonClickedAsync => nextPageNoStackButton.OnClickAsAsyncEnumerable();
        public IUniTaskAsyncEnumerable<AsyncUnit> OnPopAllButtonClickedAsync => popAllButton.OnClickAsAsyncEnumerable();

        public void SetView(EntryPageModel model)
        {
            messageText.SetText(model.Message);
        }
    }
}