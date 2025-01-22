import React from 'react';
import { PieChart, Pie, Tooltip, Cell } from 'recharts';

// Define custom colors for each segment
const COLORS = ['#0088FE', '#00C49F', '#FFBB28', '#FF8042'];

const PieChartTest = ({data}) => {
    return (
        <PieChart width={400} height={400}>
            <Pie
                data={data}
                dataKey="amount"
                nameKey="minSalary"
                cx="50%" // Center X
                cy="50%" // Center Y
                outerRadius={150} // Outer radius of the pie chart
                fill="#8884d8"
                label // Enables labels on segments
            >
                {data.map((entry, index) => (
                    <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                ))}
            </Pie>
            <Tooltip />
        </PieChart>
    );
};

export default PieChartTest;
