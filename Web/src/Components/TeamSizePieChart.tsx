import { PieChart, Pie, Tooltip, Cell } from 'recharts';

// Define custom colors for each segment
const COLORS = ['#0088FE', '#00C49F', '#FFBB28', '#FF8042'];

// @ts-ignore
const TeamSizePieChart = ({data}) => {
    // @ts-ignore
    return (
        <PieChart width={400} height={400}>
            <Pie
                data={data}
                dataKey="membersCount"
                nameKey="name"
                cx="50%" // Center X
                cy="50%" // Center Y
                outerRadius={150} // Outer radius of the pie chart
                fill="#8884d8"
                label // Enables labels on segments
            >
                {data.map((_entry: any, index: number) => (
                    <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                ))}
            </Pie>
            <Tooltip />
        </PieChart>
    );
};

export default TeamSizePieChart;
