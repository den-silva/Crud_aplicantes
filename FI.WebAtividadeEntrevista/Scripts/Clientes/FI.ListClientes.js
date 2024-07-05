
$(document).ready(function () {

    if (document.getElementById("gridClientes"))
        $('#gridClientes').jtable({
            title: 'Aplicantes',
            paging: true, //Enable paging
            pageSize: 5, //Set page size (default: 10)
            sorting: true, //Enable sorting
            defaultSorting: 'Nome ASC', //Set default sorting
            actions: {
                listAction: urlClienteList,
            },
            fields: {
                //ID: {
                //    title: 'ID',
                //    width: '5%'
                //},

                Nome: {
                    title: 'Aplicante',
                    width: '25%'
                },
                NomeCidade: {
                    title: 'Cidade',
                    width: '30%'
                },
                Nota: {
                    title: 'Nota',
                    width: '5%'
                },
                Alterar: {
                    title: 'Ações',
                    display: function (data) {
                        return '<button onclick="window.location.href=\'' + urlAlteracao + '/' + data.record.Id + '\'" class="btn btn-primary btn-sm">Alterar</button>';
                    }
                },

                Excluir: {
                    title: 'Ações',
                    display: function (data) {
                        return '<button onclick="window.location.href=\'' + urlExclusao + '/' + data.record.Id + '\'" class="btn btn-danger btn-sm">Excluir</button>';
                    }
                }
            }
        });

    //Load student list from server
    if (document.getElementById("gridClientes"))
        $('#gridClientes').jtable('load');
})