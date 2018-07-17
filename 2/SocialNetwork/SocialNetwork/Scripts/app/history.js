var ViewModel = {
    list: ko.observableArray(),
    hello:ko.observable()
}

ko.applyBindings(ViewModel);

dataContext.getInfo(ViewModel.hello, ViewModel.list);