function acumulaProduto(produto) {

    var produto = parseFloat(produto);

    var total = document.getElementById("total-vitrine").innerHTML;

    total = parseFloat(total)

    var soma = 0;

    var qtd = document.getElementById("qtdproduto").value;

    soma += parseFloat(produto * parseInt(qtd));

    total += soma

    document.getElementById("total-vitrine").innerHTML = total.toFixed(1);

    document.getElementById("card-01").style.display = "flex";

    document.getElementById("vlr-produto").innerHTML = soma;

}



function carrinho() {

    document.getElementById("modal").style.display = "block";

}

function fecharModal() {

    document.getElementById("modal").style.display = "none";
}

function excluir(exclui) {

    var total = document.getElementById("total-vitrine").innerHTML;
    var qtd = document.getElementById("qtdproduto").value;
    var menos = qtd * 42.00;

    total -= menos;

    if (exclui == "card-01") {

        document.getElementById(exclui).style.display = "none";
        document.getElementById("total-vitrine").innerHTML = total;
        document.getElementById("qtdproduto").value = 0;

    }

}


function excluir_cartaz(exclui) {

    var total = document.getElementById("total-vitrine").innerHTML;
    var qtd = document.getElementById("qtdCartaz").value;
    var menos = qtd * 1.50;

    total -= menos;

    if (exclui == "card-02") {

        document.getElementById(exclui).style.display = "none";
        document.getElementById("total-vitrine").innerHTML = total;
        document.getElementById("qtdCartaz").value = 0;

    }
}


function flyers_excluir(excluir) {
    var total = document.getElementById("total-vitrine").innerHTML;
    var qtd = document.getElementById("qtdFlyers").value;
    var menos = qtd * 88.00;

    total -= menos;

    if (excluir == "card-03") {

        document.getElementById(excluir).style.display = "none";
        document.getElementById("total-vitrine").innerHTML = total;
        document.getElementById("qtdFlyers").value = 0;

    }



}

function folders_excluir(excluir) {

    var total = document.getElementById("total-vitrine").innerHTML;
    var qtd = document.getElementById("qtdFlyers").value;
    var menos = qtd * 88.00;

    total -= menos;

    if (excluir == "card-03") {

        document.getElementById(excluir).style.display = "none";
        document.getElementById("total-vitrine").innerHTML = total;
        document.getElementById("qtdFlyers").value = 0;

    }
}

function folders_excluir(excluir) {

    var total = document.getElementById("total-vitrine").innerHTML;
    var qtd = document.getElementById("qtdFolders").value;
    var menos = qtd * 18.00;

    total -= menos;

    if (excluir == "card-04") {

        document.getElementById(excluir).style.display = "none";
        document.getElementById("total-vitrine").innerHTML = total;
        document.getElementById("qtdFolders").value = 0;

    }
}





