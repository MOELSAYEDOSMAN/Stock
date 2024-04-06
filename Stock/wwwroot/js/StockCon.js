var StoreId = "-1";
var ItemId = "-1";
//Change Store Icon
function updateStoreIcon(selectElement) {
    
    var selectedOption = selectElement.options[selectElement.selectedIndex];
    var iconUrl = selectedOption.getAttribute('data-Icon');
    document.getElementById('storeIcon').src = "/Images/" + iconUrl;
    StoreId = selectedOption.value;
    GetQuantityInStock();
}

//Change Item Icon
function updateItemIcon(selectElement) {

    var selectedOption = selectElement.options[selectElement.selectedIndex];
    var iconUrl = selectedOption.getAttribute('data-Icon');
    document.getElementById('ItemIcon').src = "/Images/" + iconUrl;
    ItemId = selectedOption.value;
    GetQuantityInStock();
}

//Get Quantity
function GetQuantityInStock() {
    if (StoreId != "-1" && ItemId != "-1") {
        document.getElementById('spinnerQuantity').style.display='flex'
        $.get("/Stock/GetQuantity", { StoreId: StoreId, ItemId: ItemId }, function (data) {
            if (data == 0) {
                document.getElementById('removeStockBtn').disabled = false;
                document.getElementById('removeStockBtn').disabled = true;
            }
            else {
                document.getElementById('removeStockBtn').disabled = false;
            }
            document.getElementById('oldQuantity').value = data;
        });
        document.getElementById('spinnerQuantity').style.display = 'none';

    }
}

//Add New Quantity
function AddQuantity() {

    var oldQuantity = document.getElementById('oldQuantity').value;
    var NewQuantity = document.getElementById('NewQuantity').value;
    
    if (StoreId != "-1" && ItemId != "-1" && NewQuantity > 0) {
        document.getElementById('spinnerAddQuantity').style.display = 'flex'
        $.get("/Stock/AddQuantity", { StoreId: StoreId, ItemId: ItemId, Quantity: NewQuantity }, function (data) {
            if (data == true) {
                document.getElementById('oldQuantity').value = '';
                document.getElementById('oldQuantity').value = String((Number.parseInt(NewQuantity) + Number.parseInt(oldQuantity)));

                 document.getElementById('NewQuantity').value = '';
                document.getElementById('removeStockBtn').disabled = false;
                alert("Save!!")
            }
            else {
                alert("Error In Data!!")
            }
            document.getElementById('spinnerAddQuantity').style.display = 'none';
        });
    }
    else {
        if (StoreId != "-1" && ItemId != "-1") {
            alert("Select item And Store")
        }
        else if (StoreId != "-1") {
            alert("Select Store")
        }
        else {
            alert("Select item")
        }
    }
}

//Remove Stock
function RemoveStock() {
    if (StoreId != "-1" && ItemId != "-1") {

        if (confirm("Are You Sure Remove Item from Stock")) {

            $.get("/Stock/RemoveStock", { StoreId: StoreId, ItemId: ItemId }, function (data) {
                if (data == 1) {
                    document.getElementById('oldQuantity').value = 0;
                    document.getElementById('removeStockBtn').disabled = true;
                    alert("Done!")
                }
                else if (data == 2) {
                    alert("A Item That Is Not Present in The Stock");
                }
                else {
                    alert("Error In Data")
                }
            });

        }
        else {
            if (StoreId != "-1" && ItemId != "-1") {
                alert("Select item And Store")
            }
            else if (StoreId != "-1") {
                alert("Select Store")
            }
            else {
                alert("Select item")
            }
        }

    }
}