$(document).ready(function () {
    $('#txtfechafin, #txtfechainicio').datepicker({
        changeMonth: true,
        changeYear: true,
        dateFormat: "dd/mm/yy",
        firstDay: 1,
        changeFirstDay: false,
        placeholder: "dd/MM/yyyy"
    });

    $('#txtfechafin').val(GetFecha());
    $('#txtfechainicio').val(GetFecha());


});

// METODO QUE VALIDA LA FECHA
const validateDate = (birthDate) => {
    const DATE_REGEX = /^(0[1-9]|[1-2]\d|3[01])(\/)(0[1-9]|1[012])\2(\d{4})$/

    /* Comprobar formato dd/mm/yyyy, que el no sea mayor de 12 y los días mayores de 31 */
    if (!birthDate.match(DATE_REGEX)) {
        return false
    }

    /* Comprobar los días del mes */
    const day = parseInt(birthDate.split('/')[0])
    const month = parseInt(birthDate.split('/')[1])
    const year = parseInt(birthDate.split('/')[2])
    const monthDays = new Date(year, month, 0).getDate()
    if (day > monthDays) {
        return false
    }

    /* Comprobar que el año no sea superior al actual*/
    //if (year > CURRENT_YEAR) {
    //    return false
    //}
    return true
}

const GetFecha = () => {
    var f = new Date();
    var fechaActual = '';
    fechaActual = (("0" + f.getDate()).slice(-2) + "/" + ("0" + (f.getMonth() + 1)).slice(-2) + "/" + f.getFullYear());
    return fechaActual;
}


////METODO QUE TRAE LA FECHA HOY
//function GetFecha() {

//    var f = new Date();
//    var fechaActual = '';
//    fechaActual = (("0" + f.getDate()).slice(-2) + "/" + ("0" + (f.getMonth() + 1)).slice(-2) + "/" + f.getFullYear());
//    return fechaActual;
//}