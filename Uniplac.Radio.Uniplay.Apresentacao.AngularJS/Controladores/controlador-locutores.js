application.controller('controlador-locutores', function ($scope, $http) {

    var ADICIONADO = 'ADICIONADO';
    var EXCLUIDO = 'EXCLUIDO';
    var ALTERADO = 'ALTERADO';

    $scope.servico = { host: 'http://localhost:3969/api/', controlador: 'Locutor' };

    $scope.configurar_url = function () {
        return $scope.servico.host + $scope.servico.controlador;
    }

    $scope.adicionar = function (dados) {
        var url = $scope.configurar_url();
        $http.post(url, dados).success(function () {
            alert('Registro adicionado com sucesso');
            carregar_todos_registros();
        }).error(function () {
            alert('Falha ao adicionar o registro');
        });
    }

    $scope.excluir = function (dados) {
        var url = $scope.configurar_url();
        $http.delete(url, dados).success(function () {
            alert('Registro excluido com sucesso');
            carregar_todos_registros();
            delete $scope.modelo;
        }).error(function () {
            alert('Falha ao excluir o registro');
        });
    }

    $scope.alterar = function (dados) {
        var url = $scope.configurar_url();
        $http.put(url, dados).success(function () {
            alert('Registro alterado com sucesso');
            carregar_todos_registros();
        }).error(function () {
            alert('Falha ao alterar o registro');
        });
    }

    $scope.carregar_todos_registros = function () {
        var url = $scope.configurar_url();
        $http.get(url).success(function (dados) {
            $scope.locutores = dados;
            $scope.locutores = [{ Nome: "Teste", Sobrenome: "Teste" }, { Nome: "Testes2", Sobrenome: "------" }];
        }).error(function () {
            alert('Falha ao carregar os registros');
        });
    }

    $scope.salvar = function (dados) {
        for (registro in dados) {
            if (dados[registro].estado == ADICIONADO) {
                $scope.adicionar(dados[registro]);
            }
            if (dados[registro].estado == ALTERADO) {
                $scope.alterar(dados[registro]);
            }
            if (dados[registro].estado == EXCLUIDO) {
                $.$scope.excluir(dados[registro]);
            }
        }
    }

    $scope.marcar_para_edicao = function (registro) {
        registro.estado = ALTERADO;
    }

    $scope.marcar_para_exclusao = function (registro) {
        registro.estado = EXCLUIDO;
    }

    $scope.locutores = $scope.carregar_todos_registros();
});
