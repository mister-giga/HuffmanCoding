var graphNetwork = null;
var graphData = null;

function destroy() {
    if (graphNetwork !== null) {
        graphNetwork.destroy();
        graphNetwork = null;
    }
}


window.loadSvgGraph = (data) => {
    graphData = data;
    draw();
}

window.addEventListener("resize", draw);



function draw() {
    destroy();
    var container = document.getElementById("graphviz_svg_div");

    if (!graphData || !container) {
        return;
    }
    
    var options = {
        layout: {
            hierarchical: {
                direction: 'UD',
            },
        },
        edges: {
            arrows: "to",
            smooth: {
                type: "cubicBezier",
                forceDirection: "vertical",
                roundness: 0.4,
            },
        },
        physics: false,
        interaction: {
            dragNodes: false,
        },
        autoResize: false
    };

    const jData = JSON.parse(graphData);
    console.log(jData);
    graphNetwork = new vis.Network(container, jData, options);
    console.log(graphNetwork);
}