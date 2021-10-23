using HuffmanCoding.Models;
using Microsoft.AspNetCore.Components;

namespace HuffmanCoding.Services
{
    public class PageStateValidator
    {
        public PageStateValidator(HuffmanCoder huffmanCoder, NavigationManager navigationManager, CharInfoStore charInfoStore)
        {
            HuffmanCoder = huffmanCoder; 
            NavigationManager = navigationManager; 
            CharInfoStore = charInfoStore;
        }

        public HuffmanCoder HuffmanCoder { get; }
        public NavigationManager NavigationManager { get; }
        public CharInfoStore CharInfoStore { get; }

        public bool NeedsInput()
        {
            if (!HuffmanCoder.IsAvailable)
            {
                NavigationManager.NavigateTo("/");
                return true;
            }

            CharInfoStore.ResetData(HuffmanCoder.Input);

            return false;
        }
    }
}
