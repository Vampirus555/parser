using System.Collections.Generic;
using System.Windows.Data;
using System.Collections;
using System.ComponentModel;

namespace PoserParser
{
	public class PagingCollectionView : CollectionView
    {
        private IList innerList;
        private int itemsPerPage;

        private int currentPage = 1;

        public PagingCollectionView(Dictionary<int, object> inputList, int itemsPerPage, bool ifKeys)
            : base(DicKeysToList(inputList))
        {
            this.itemsPerPage = itemsPerPage;
            this.innerList = DicKeysToList(inputList);
        }

        public PagingCollectionView(Dictionary<int, object> inputList, int itemsPerPage)
            : base(DicValuesToList(inputList))
        {
            this.itemsPerPage = itemsPerPage;
            this.innerList = DicValuesToList(inputList);
        }

        public PagingCollectionView(Dictionary<int, UBIFull> inputList, int itemsPerPage)
            : base(DicValuesToList(inputList))
        {
            this.itemsPerPage = itemsPerPage;
            this.innerList = DicValuesToList(inputList);
        }

        public PagingCollectionView(Dictionary<int, UBIShort> inputList, int itemsPerPage)
            : base(DicValuesToList(inputList))
        {
            this.itemsPerPage = itemsPerPage;
            this.innerList = DicValuesToList(inputList);
        }
        public PagingCollectionView(List<object> inputList, int itemsPerPage)
            : base(inputList)
        {
            this.itemsPerPage = itemsPerPage;
            this.innerList = inputList;
        }

        public override int Count
        {
            get
            {
                if (this.innerList.Count == 0) return 0;
                if (this.currentPage < this.PageCount)
                    return this.itemsPerPage;
                else
                {
                    var itemsLeft = this.innerList.Count % this.itemsPerPage;
                    if (0 == itemsLeft)
                        return this.itemsPerPage;
                    else
                        return itemsLeft;
                }
            }
        }

        public int CurrentPage
        {
            get { return this.currentPage; }
            set
            {
                this.currentPage = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("CurrentPage"));
            }
        }

        public int ItemsPerPage { 
            set 
            { 
                this.CurrentPage = 1;
                itemsPerPage = value; 
                this.Refresh();
            } 
            get { return this.itemsPerPage; } 
        }

        public int PageCount
        {
            get { return (this.innerList.Count + this.itemsPerPage - 1) / this.itemsPerPage; }
        }

        private int EndIndex
        {
            get
            {
                var end = this.currentPage * this.itemsPerPage - 1;
                return (end > this.innerList.Count) ? this.innerList.Count : end;
            }
        }

        private int StartIndex
        {
            get { return (this.currentPage - 1) * this.itemsPerPage; }
        }

        public override object GetItemAt(int index)
        {
            var offset = index % (this.itemsPerPage);
            return this.innerList[this.StartIndex + offset];
        }

        public void MoveToNextPage()
        {
            if (this.currentPage < this.PageCount)
                this.CurrentPage += 1;
            this.Refresh();
        }

        public void MoveToPreviousPage()
        {
            if (this.currentPage > 1)
                this.CurrentPage -= 1;
            this.Refresh();
        }

        private static List<object> DicKeysToList(Dictionary<int, object> input)
        {
            var list = new List<object>();
            foreach (var item in input)
                list.Add(item.Key);
            return list;
        }

        private static List<object> DicValuesToList(Dictionary<int, object> input)
		{
            var list = new List<object>();
			foreach (var item in input)
                list.Add(item.Value);
            return list;
		}
        private static List<object> DicValuesToList(Dictionary<int, UBIFull> input)
		{
            var list = new List<object>();
			foreach (var item in input)
                list.Add(item.Value);
            return list;
		}
        private static List<object> DicValuesToList(Dictionary<UBIFull, string> input)
		{
            var list = new List<object>();
			foreach (var item in input)
                list.Add(item.Key);
            return list;
		}
        private static List<object> DicValuesToList(Dictionary<int, UBIShort> input)
		{
            var list = new List<object>();
			foreach (var item in input)
                list.Add(item.Value);
            return list;
		}
    }
}