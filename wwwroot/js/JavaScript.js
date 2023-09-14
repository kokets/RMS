class AnimationsHandler {
    constructor() {

        //initialize the text animation
        this.initTextAnimation();
        //this.openModal();

        //bind slideOut and slideIn method to the class instance
        //bind ensures that the value of this inside the function is what the user expect it to be 
        this.slideOut = this.slideOut.bind(this);
        this.slideIn = this.slideIn.bind(this);
        this.openForm = null; // Track the currently open form
        this.toggleFormDisplay = this.toggleFormDisplay.bind(this);


    }
    initTextAnimation() {
        var textWrapper = document.querySelector('.anim-text');
        textWrapper.innerHTML = textWrapper.textContent.replace(/\S/g, "<span class='letter'>$&</span>");

        anime.timeline({ loop: true })
            .add({
                targets: '.anim-text .letter',
                scale: [4, 1],
                opacity: [0, 1],
                translateZ: 0,
                easing: "easeOutExpo",
                duration: 950,
                delay: (el, i) => 70 * i
            })
            .add({
                targets: '.anim-text',
                opacity: 0,
                duration: 1000,
                easing: "easeOutExpo",
                delay: 100
            });

        const rows = Array.from(document.querySelectorAll('tr'));
        rows.forEach(this.slideOut);
        rows.forEach(this.slideIn);
    }


    //function to reset all the table rows
    resetTableRows() {
        const rows = Array.from(document.querySelectorAll('tr'));
        rows.forEach((row) => {
            row.classList.remove('slide-out', 'slide-in');
        });
    }



    showTable(tableId) {
        this.resetTableRows();

        const tableTemplates = document.getElementsByClassName('table-template');

        for (let i = 0; i < tableTemplates.length; ++i) {
            tableTemplates[i].style.display = 'none';
        }

        //show the selected table template

        const selectedTable = document.getElementById(tableId);

        if (selectedTable) {
            selectedTable.style.display = 'block';
            const rows = Array.from(selectedTable.querySelectorAll('tr'));
            rows.forEach(this.slideOut);
            rows.forEach(this.slideIn);
        }
    }
    slideOut(row) {
        row.classList.add('slide-out');

    }
    slideIn(row, index) {
        setTimeout(function () {
            row.classList.remove('slide-out');
            row.classList.add('slide-in');
        }, (index + 5) * 200);
    }


    toggleFormDisplay(formId) {
        const form = document.getElementById(formId);

        if (!form) {
            console.error(`Form with ID ${formId} not found.`);
            return;
        }

        if (this.openForm !== null && this.openForm !== form) {
            this.openForm.style.display = 'none'; // Close the previously open form
        }

        if (form.style.display === 'none') {
            form.style.display = 'block';
            this.openForm = form;
        } else {
            form.style.display = 'none';
            this.openForm = null;
        }
    }



}
class TinyFormHandler {
    constructor() {
        tinymce.init({
            selector: '#editor1',
            height: 300,
            menubar: false,
            plugins: ['advlist autolink lists link image charmap print preview anchor',
                'searchreplace visualblocks code fullscreen',
                'insertdatetime media table paste code help wordcount'],
            toolbar: 'formatselect | fontselect | fontsizeselect | bold italic underline | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | code',
            content_style: 'body { font-family: Arial, sans-serif; font-size: 14px; }'
        });

        tinymce.init({
            selector: '#editor2',
            height: 200,
            menubar: false,
            plugins: ['advlist autolink lists link image charmap print preview anchor',
                'searchreplace visualblocks code fullscreen',
                'insertdatetime media table paste code help wordcount'],
            toolbar: 'formatselect | fontselect | fontsizeselect | bold italic underline | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | code',
            content_style: 'body { font-family: Arial, sans-serif; font-size: 14px; }'
        });
    }
}

class ModalHandler {
    constructor() {
        this.modals = {};
    }
    registerModal(modalId) {
        this.modals[modalId] = document.getElementById(modalId);
    }
    openModal(modalId) {
        const modal = this.modals[modalId];
        if (modal) {
            modal.style.display = "block";
        }
    }
    closeModal(modalId) {
        const modal = this.modals[modalId];
        if (modal) {
            modal.classList.add('modal-closing');
            setTimeout(() => {
                modal.style.display = "none";
                modal.classList.remove('modal-closing');
            }, 300);
        }
    }

    handleActionChange(selectId) {
        const selectElement = document.getElementById(selectId);
        const selectedValue = selectElement.value;

        // Add your conditions here to open specific modals
        // For example:
        if (selectId === "action-select1") {
            if (selectedValue === "Edit") {
                this.openModal('myModal');
            }
        }
        else if (selectId === "action-select-level ") {
            if (selectedValue === "DeleteProject") {
                this.openModal('myModal');

            }
            else if (selectedValue === "Link") {
                this.openModal('myModal1');

            }
            else if (selectedValue === "copy") {
                this.openModal('myModal1');

            }
        }
        else if (selectId === "action-select") {
            if (selectedValue === "View") {
                this.openModal('myModal');

            }
            else if (selectedValue === "Activity") {
                this.openModal('myModal1');

            }
            else if (selectedValue === "Assign") {
                this.openModal('myModal2');
            }
        }
    }

    handleActionNavigation(selectedId) {
        const selectElement = document.getElementById(selectedId);

        if (selectElement) {
            // Add event listener to the <select> element
            selectElement.addEventListener("change", function () {
                // Get the selected option value
                var selectedOption = selectElement.value;

                // Perform the action based on the selected option
                switch (selectedOption) {
                    case "Edit":
                        // Redirect to the "AssignKeyword" view
                        window.location.href = "/DataSetProjectLevelEdit"; // Replace "ControllerName" with the actual controller name and "AssignKeyword" with the view name.
                        break;
                    case "Keyword":
                        // Redirect to the "AssignCounties" view
                        window.location.href = "/DataSetProjectLevelKey"; // Replace "ControllerName" with the actual controller name and "AssignCounties" with the view name.
                        break;

                    case "Countries":
                        // Redirect to the "AssignCounties" view
                        window.location.href = "/DataSetProjectLevelCountry"; // Replace "ControllerName" with the actual controller name and "AssignCounties" with the view name.
                        break;
                    case "Status":
                        // Redirect to the "AssignCounties" view
                        window.location.href = "/DataSetProjectLevelStatus"; // Replace "ControllerName" with the actual controller name and "AssignCounties" with the view name.
                        break;
                    //case "View":
                    //    // Redirect to the "AssignKeyword" view
                    //    window.location.href = "/MoUViewRegister"; // Replace "ControllerName" with the actual controller name and "AssignKeyword" with the view name.
                    //    break;
                    case "View1":
                        // Redirect to the "AssignCounties" view
                        window.location.href = "/LicenseMActivations"; // Replace "ControllerName" with the actual controller name and "AssignCounties" with the view name.
                        break;

                    //case "Activity":
                    //    // Redirect to the "AssignCounties" view
                    //    window.location.href = "/MoUActivityEdit"; // Replace "ControllerName" with the actual controller name and "AssignCounties" with the view name.
                    //    break;
                    case "Edit1":
                        // Redirect to the "AssignKeyword" view
                        window.location.href = "/MoUManage1Edit"; // Replace "ControllerName" with the actual controller name and "AssignKeyword" with the view name.
                        break;
                    case "Edit2":
                        // Redirect to the "AssignCounties" view
                        window.location.href = "/LicenseListEdit"; // Replace "ControllerName" with the actual controller name and "AssignCounties" with the view name.
                        break;
                    case "Edit3":
                        // Redirect to the "AssignCounties" view
                        window.location.href = "/LicenseListTypesEdit"; // Replace "ControllerName" with the actual controller name and "AssignCounties" with the view name.
                        break;

                    case "Delete":
                        // Redirect to the "AssignCounties" view
                        window.location.href = "/MoUManage1Delete"; // Replace "ControllerName" with the actual controller name and "AssignCounties" with the view name.
                        break;



                    default:
                        // Handle invalid option or other cases
                        break;
                }
            });
        }
    }



}

class MethodHandler {
    constructor() {
        this.GiftMandatoryField = ["GiftSponsor",
            "NatureOfBusiness",
            "Value",
            "ReceivedInAppreciation"];

    }

    GiftValidateForm() {
        let isValid = true;
        for (const fieldId of this.GiftMandatoryField) {
            const field = document.getElementById(fieldId);
            if (!field.value) {
                isValid = false;
                field.classList.add("invalid-field");
            } else {
                field.classList.remove("invalid-field");
            }
        }
        if (!isValid) {
            alert("Please fill in all mandatory fields.");
            return false; // Prevent form submission
        }

        // If the form is valid, submit it using AJAX
        $.ajax({
            type: "POST",
            url: "/GiftRegister/Index", // The URL where the form should be submitted
            data: $("form").serialize(), // Serialize form data
            success: function () {
                // Show a success popup with a delay
                setTimeout(function () {
                    Swal.fire({
                        icon: "success",
                        title: "Success",
                        text: "Gift registered successfully.",
                    }).then(() => {
                        // Redirect to the "GiftDisplay" page upon popup close
                        window.location.href = "/GiftDisplay";
                    });
                }, 1500); // Delay in milliseconds (1.5 seconds)
            },
            error: function () {
                alert("An error occurred while submitting the form.");
            }
        });

        return false; // Prevent default form submission
    }


    filterTable() {
        const searchInput = document.getElementById('search-input');
        const filterValue = searchInput.value.toLowerCase();

        const tbody = document.querySelector('#event-table tbody');
        const rows = tbody.getElementsByTagName('tr');

        for (const row of rows) {
            const cells = row.getElementsByTagName('td');
            let found = false;

            for (const cell of cells) {
                if (cell.textContent.toLowerCase().indexOf(filterValue) > -1) {
                    found = true;
                    break;
                }
            }

            row.style.display = found ? '' : 'none';
        }
    }
    
    ExportToExcel(type) {
        var elt = document.getElementById('event-table');
        var wb = XLSX.utils.table_to_book(elt, { sheet: "sheet1" });

        // Specify the desired date format
        var dateFormat = 'yyyy-MM-dd';

        // Set date format for Excel
        var ws = wb.Sheets["sheet1"];
        ws["!cols"] = [
            { wch: 15 }, { wch: 15 }, { wch: 15 }, /* ... other column widths ... */
            { wch: dateFormat.length } // Set column width for date column
        ];
        ws["!dateFormats"] = [dateFormat]; // Set the desired date format

        var blob = null;
        if (type === 'xlsx') {
            blob = XLSX.write(wb, { bookType: type, bookSST: true, type: 'blob', dateNF: dateFormat });
        } else {
            blob = new Blob([XLSX.write(wb, { bookType: 'csv', bookSST: true, type: 'base64', dateNF: dateFormat })], {
                type: 'text/csv;charset=utf-8;'
            });
        }

        const url = URL.createObjectURL(blob);
        window.location.href = url; // Opens the file in Excel or downloads the CSV
    }

    printTableData() {
    var divToPrint = document.getElementById("event-table");
    var newWin = window.open("");
    newWin.document.write(divToPrint.outerHTML);
    newWin.print();
    newWin.close();
}
}
class PdfCopyExcelCsv {
    static ExportToExcel(type, fn, dl) {
        var elt = document.getElementById('event-table');
        var wb = XLSX.utils.table_to_book(elt, { sheet: "sheet1" });

        // Specify the desired date format
        var dateFormat = 'yyyy-MM-dd';

        // Set date format for Excel
        var ws = wb.Sheets["sheet1"];
        ws["!cols"] = [
            { wch: 15 }, { wch: 15 }, { wch: 15 }, /* ... other column widths ... */
            { wch: dateFormat.length } // Set column width for date column
        ];
        ws["!dateFormats"] = [dateFormat]; // Set the desired date format

        return dl ?
            XLSX.write(wb, { bookType: type, bookSST: true, type: 'base64', dateNF: dateFormat }) :
            XLSX.writeFile(wb, fn || ('Gift.' + (type || 'xlsx')));
    }
}
const pdfCopyExcelCsv = new PdfCopyExcelCsv();
const methodHandler = new MethodHandler();
const modalHandler = new ModalHandler();
const animationsHandler = new AnimationsHandler();
const tinyFormHandler = new TinyFormHandler();
