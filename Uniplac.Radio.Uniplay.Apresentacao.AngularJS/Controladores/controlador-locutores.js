application.controller('controlador-locutores', function ($scope, $http) {

    $scope.adicionar = function (dados) {
        $http.post('http://localhost:3969/api/Locutor', dados).success(function () {
            alert('Registro adicionado com sucesso');
            carregar_todos_registros();
        }).error(function () {
            alert('Falha ao adicionar o registro');
        });
    }

    $scope.excluir = function (dados) {
        $http.delete('http://localhost:3969/api/Locutor/'+ dados.Id).success(function () {
            alert('Registro excluido com sucesso');
            carregar_todos_registros();
            delete $scope.modelo;
        }).error(function () {
            alert('Falha ao excluir o registro');
        });
    }

    $scope.alterar = function (dados) {
        $http.put('http://localhost:3969/api/Locutor/' + dados.Id, dados).success(function () {
            alert('Registro alterado com sucesso');
            carregar_todos_registros();
        }).error(function () {
            alert('Falha ao alterar o registro');
        });
    }

    var carregar_todos_registros = function () {
        $http.get('http://localhost:3969/api/Locutor').success(function (dados) {
            $scope.locutores = dados;
        }).error(function () {
            alert('Falha ao carregar os registros');
        });
    }

    carregar_todos_registros();
});
