var ViewModel = {
    postDialog: new postDialogViewModel(ko),
    addFoodModal: new addFoodModalViewModel(ko)
}

function postDialogViewModel(ko) {
    var self = this;
    self.name = ko.observable();
    self.email = ko.observable();

    self.foods = ko.observableArray();
    self.valueFood = ko.observable();
    self.errors = ko.observableArray();


    self.share = () => {
        if (self.validation()) {
            dataContext.addPost({
                FoodId: self.valueFood(),
                Name: self.name(),
                Email: self.email()
            }, () => {
                location.href = "/history";
            }, self.errors)
        }
        setTimeout(() => {
            self.errors([]);
        }, 2000)
    }

    self.validation = () => {
        var valid = true;

        $("#inputNameError").text("")
        $("#inputEmailError").text("");
        $("#inputFoodError").text("");

        if (!self.name()) {
            var err = "Заполните поле Имя!";
            valid = false;
            $("#inputNameError").text(err);
        }

        if (!self.email()) {
            var err = "Заполните поле Email!"
            valid = false;
            $("#inputEmailError").text(err);
        }

        if (!self.valueFood()) {
            var err = "Заполните поле Еда!"
            valid = false
            $("#inputFoodError").text(err);
        }

        return valid;
    }
}

function addFoodModalViewModel(ko) {
    var self = this;

    self.name = ko.observable();
    self.error = ko.observable();

    self.onSubmit = () => {
        if (self.validation()) {
            dataContext.addFood({ Name: self.name() }, (food) => {
                ViewModel.postDialog.foods.push({ Id: food.Id, Value: food.Name });
                $("#addFoodModal").modal("hide");
            }, self.error);
        } else {
            self.error("Заполните поле Имя!")
        }
    }

    self.validation = () => {
        return self.name() ? true : false
    }

    self.reset = () => {
        self.name("");
        self.error("")
    }
}

$(function () {
ko.applyBindings(ViewModel);

dataContext.getFood(ViewModel.postDialog.foods)

$('#addFoodModal').on('hide.bs.modal', () => {
    ViewModel.addFoodModal.reset();
});
})
