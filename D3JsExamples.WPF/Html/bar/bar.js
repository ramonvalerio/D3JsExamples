function type(d) {

    alert(d);

    d.frequency = +d.frequency;
    return d;
}

function GerarGrafico() {

    //var data = "[{ 'letter': 'A', 'frequency': '.8167' }, { 'letter': 'B', 'frequency': '.8168' }, { 'letter': 'C', 'frequency': '.8169' }]";

    var source = [{ "letter": "A", "frequency": 20 }, {
        "letter": "B",
        "frequency": 12
    }, {
        "letter": "C",
        "frequency": 47
    }, {
        "letter": "D",
        "frequency": 34
    }, {
        "letter": "E",
        "frequency": 54
    }, {
        "letter": "F",
        "frequency": 21
    }, {
        "letter": "G",
        "frequency": 57
    }, {
        "letter": "H",
        "frequency": 31
    }, {
        "letter": "I",
        "frequency": 17
    }, {
        "letter": "J",
        "frequency": 5
    }, {
        "letter": "K",
        "frequency": 23
    }, {
        "letter": "L",
        "frequency": 39
    }, {
        "letter": "M",
        "frequency": 29
    }, {
        "letter": "N",
        "frequency": 33
    }, {
        "letter": "O",
        "frequency": 18
    }, {
        "letter": "P",
        "frequency": 35
    }, {
        "letter": "Q",
        "frequency": 11
    }, {
        "letter": "R",
        "frequency": 45
    }, {
        "letter": "S",
        "frequency": 43
    }, {
        "letter": "T",
        "frequency": 28
    }, {
        "letter": "U",
        "frequency": 26
    }, {
        "letter": "V",
        "frequency": 30
    }, {
        "letter": "X",
        "frequency": 5
    }, {
        "letter": "Y",
        "frequency": 4
    }, {
        "Letter": "Z",
        "frequency": 2
    }];

    alert(source[0].letter);
    alert(source[0].frequency);

    var margin = { top: 40, right: 20, bottom: 30, left: 40 },
    width = 960 - margin.left - margin.right,
    height = 500 - margin.top - margin.bottom;

    var formatPercent = d3.format(".0%");

    var x = d3.scale.ordinal()
        .rangeRoundBands([0, width], .1);

    var y = d3.scale.linear()
        .range([height, 0]);

    var xAxis = d3.svg.axis()
        .scale(x)
        .orient("bottom");

    var yAxis = d3.svg.axis()
        .scale(y)
        .orient("left")
        .tickFormat(formatPercent);

    var tip = d3.tip()
      .attr('class', 'd3-tip')
      .offset([-10, 0])
      .html(function (d) {
          return "<strong>Frequency:</strong> <span style='color:red'>" + d.frequency + "</span>";
      })

    var svg = d3.select("body").append("svg")
        .attr("width", width + margin.left + margin.right)
        .attr("height", height + margin.top + margin.bottom)
      .append("g")
        .attr("transform", "translate(" + margin.left + "," + margin.top + ")");

    svg.call(tip);

    d3.json(source, function (error, data) {

        data.forEach(function (d) {

            alert(d.letter);
            alert(d.frequency);

            d.letter = d.letter;
            d.frequency = +d.frequency;
        });

        //x.domain(data.map(function (d) { return d.letter; }));
        //x.domain(json.map(function (d) { return d["letter"]; }));

        //y.domain([0, d3.max(data, function (d) { return d.frequency; })]);
        //y.domain([0, d3.max(data, function (d) { return d["frequency"]; })]);

        svg.append("g")
            .attr("class", "x axis")
            .attr("transform", "translate(0," + height + ")")
            .call(xAxis);

        svg.append("g")
            .attr("class", "y axis")
            .call(yAxis)
          .append("text")
            .attr("transform", "rotate(-90)")
            .attr("y", 6)
            .attr("dy", ".71em")
            .style("text-anchor", "end")
            .text("Frequency");

        svg.selectAll(".bar")
            .data(data)
          .enter().append("rect")
            .attr("class", "bar")
            .attr("x", function (d) { return x(d.letter); })
            .attr("width", x.rangeBand())
            .attr("y", function (d) { return y(d.frequency); })
            .attr("height", function (d) { return height - y(d.frequency); })
            .on('mouseover', tip.show)
            .on('mouseout', tip.hide)
    });
}