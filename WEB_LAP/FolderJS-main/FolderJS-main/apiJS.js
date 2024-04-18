const express = require('express');
const app = express();
const port = 3000;

app.get('/GrossProfitability', (req, res) => {
  const { GrossProfit, RealizationProduct } = req.query;
  const GrossProfitability = parseFloat(GrossProfit) / parseFloat(RealizationProduct);
  const percentValue = GrossProfitability * 100;
  const result = percentValue.toFixed(2) + ' %';
  res.json({ 'Валовая рентабельность продукции = ': result });
});

app.get('/Revenue_forecast_by_the_end_of_the_month', (req, res) => {
  const { Fact_revenue, Lasts_days, Remains_days } = req.query;
  const FORECAST = parseInt(Fact_revenue) / (parseInt(Lasts_days) * parseInt(Remains_days));
  res.json({ 'Прогноз выручки до конца месяца = ': FORECAST.toFixed(2) });
});

app.get('/The_forecast_of_the_implementation_of_the_plan_as_a_percentage', (req, res) => {
  const { FORECAST, Plan_revenue } = req.query;
  const PERCENTAGE_FORECAST = (parseInt(FORECAST) * 100) / parseInt(Plan_revenue);
  res.json({ 'Выполнение плана на % (прогноз) = ': PERCENTAGE_FORECAST.toFixed(2) + ' %' });
});

app.listen(port, () => {
  console.log(`Server is running at http://localhost:${port}`);
});
